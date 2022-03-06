package com.DebateSystem1111111.demo.modle;

import javax.persistence.*;
import java.util.ArrayList;

@Entity(name = "Topics")
@Table(
        name = "Topics"
)
public class Topics {
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
    private String topicName;
    private Integer popularity;

    @ManyToMany(targetEntity = ApplicationUser.class)
    private ArrayList<ApplicationUser> users = new ArrayList<>();

    public Topics(String topicName, Integer popularity) {
        this.topicName = topicName;
        this.popularity = popularity;
    }

    public Topics(){
    }

    public String getTopicName() {
        return topicName;
    }

    public Integer getPopularity() {
        return popularity;
    }

    public void setTopicName(String topicName) {
        this.topicName = topicName;
    }

    public void setPopularity(Integer popularity) {
        this.popularity = popularity;
    }

    public ArrayList<ApplicationUser> getUsers(){
        return this.users;
    }

    public void setUsers(ApplicationUser user){
        this.users.add(user);
    }
}
