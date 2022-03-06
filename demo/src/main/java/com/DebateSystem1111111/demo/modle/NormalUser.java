package com.DebateSystem1111111.demo.modle;


import javax.persistence.Entity;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import java.util.ArrayList;

@Entity(name = "NormalUser")
public class NormalUser extends ApplicationUser {
    private Integer rating;


    public NormalUser(String email, String passWord, String userName,Integer rating,Long ID) {
        super(email, passWord, userName,ID);
        this.rating = rating;
    }

    public NormalUser(String email, String passWord, String userName,Integer rating) {
        super(email, passWord, userName);
        this.rating = rating;
    }

    public NormalUser() {
    }

    public Integer getRating(){
        return rating;
    }
    public void setRating(Integer rating){
        this.rating = rating;
    }


}

