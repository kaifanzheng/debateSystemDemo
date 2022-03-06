package com.DebateSystem1111111.demo.DAO;

import com.DebateSystem1111111.demo.modle.NormalUser;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public interface NormalUserRepository extends JpaRepository<NormalUser,Long> {

    //@Query("SELECT s FROM ApplicationUser s WHERE s.email = ?1")
    ArrayList<NormalUser> findNormalUserByEmail(String email);
    ArrayList<NormalUser> findNormalUserByUserName(String userName);
    NormalUser findNormalUserByID(Long ID);
}
