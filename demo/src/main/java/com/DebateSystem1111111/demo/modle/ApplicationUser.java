package com.DebateSystem1111111.demo.modle;

import com.DebateSystem1111111.demo.Service.EmailVarifyLogic.VerifyEmail;

import javax.persistence.*;
import java.util.ArrayList;

@Entity(name = "ApplicationUser")
@Table(
        name = "ApplicationUser",
        uniqueConstraints = {
                @UniqueConstraint(name = "User_email_unique",columnNames = "email"),
                @UniqueConstraint(name = "User_name_unique", columnNames = "user_name")
        }
)
public class ApplicationUser {
    @Id
    @SequenceGenerator(
            name = "applicationUser_sequence",
            sequenceName = "ApplicationUser_sequence",
            allocationSize =  1
    )
    @GeneratedValue(
            strategy = GenerationType.SEQUENCE,
            generator = "ApplicationUser_sequence"
    )
    @Column(
            name = "ID",
            updatable = false
    )
    private Long ID;
    @Column(
            name = "email",
            nullable = false,
            columnDefinition =  "TEXT"
    )
    private String email;
    @Column(
            name = "password",
            columnDefinition =  "TEXT",
            nullable = false
    )
    private String passWord;
    @Column(
            name = "user_name",
            nullable = false,
            columnDefinition =  "TEXT"
    )
    private String userName;
    @Column(
            name = "emailActivate",
            nullable = false
    )
    private Boolean isActivated;
    @Column(
            name = "verificationCode",
            nullable = false
    )
    private String verificationCode;

    @ManyToMany(targetEntity = Topics.class)
    @JoinTable(
            name = "users_topics",
            joinColumns = @JoinColumn(name = "UserId"),
            inverseJoinColumns = @JoinColumn(name = "topicId")
    )
    private ArrayList<Topics> topics = new ArrayList<>();

    public  ApplicationUser(String email, String passWord, String userName){
        this.email = email;
        this.passWord = passWord;
        this.userName = userName;
        this.isActivated = false;
        this.verificationCode = VerifyEmail.sendVerification(email);
    }
    public  ApplicationUser(String email, String passWord, String userName, Long ID){
        this.email = email;
        this.passWord = passWord;
        this.userName = userName;
        this.ID = ID;
        this.isActivated = false;
        this.verificationCode = VerifyEmail.sendVerification(email);
    }

    public ApplicationUser() {
        this.isActivated = false;
    }

    public Long getID() {
        return ID;
    }

    public void setID() {
        this.ID =ID;
    }

    public void setEmail(String email){
        this.verificationCode = VerifyEmail.sendVerification(email);
        this.isActivated = false;
        this.email = email;
    }
    public String getEmail(){
        return this.email;
    }
    public void setUserName(String name){
        this.userName = name;
    }
    public String getUserName(){
        return this.userName;
    }
    public void setPassword(String passWord){
        this.passWord = passWord;
    }
    public String getPassWord(){
        return  this.passWord;
    }

    public Boolean getIsActivated(){
        return this.isActivated;
    }

    public void setIsActivated(boolean isActivated){
        this.isActivated = isActivated;
    }
    public String getVerificationCode(){
        return this.verificationCode;
    }
    public void setVerificationCode(String verificationCode){
        this.verificationCode = verificationCode;
    }

    @Override
    public String toString() {
        return "ApplicationUser{" +
                "ID=" + ID +
                ", email='" + email + '\'' +
                ", passWord='" + passWord + '\'' +
                ", userName='" + userName + '\'' +
                '}';
    }

    public ArrayList<Topics> getTopics(){
        return this.topics;
    }
    public void addTopics(Topics topic){
        this.topics.add(topic);
    }
}