package com.DebateSystem1111111.demo.Service;

import com.DebateSystem1111111.demo.DAO.NormalUserRepository;
import com.DebateSystem1111111.demo.Service.EmailVarifyLogic.VerifyEmail;
import com.DebateSystem1111111.demo.modle.NormalUser;
import org.apache.commons.validator.routines.EmailValidator;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class NormalUserService {
    private final NormalUserRepository normalUserRepository;

    @Autowired
    public NormalUserService(NormalUserRepository normalUserRepository){
        this.normalUserRepository = normalUserRepository;
    }

    public NormalUser getNormalUserByID(Long id) {
        return normalUserRepository.findNormalUserByID(id);
    }

    public List<NormalUser> getNormalUsers(){
        return  normalUserRepository.findAll();
    }

    public void addNormalUser(NormalUser normalUser) {
        ArrayList<NormalUser> userByEmail =
                normalUserRepository.findNormalUserByEmail(normalUser.getEmail());
        if(!userByEmail.isEmpty()){
            throw new IllegalStateException("the email already exists");
        }
        if(!EmailValidator.getInstance(true).isValid(normalUser.getEmail())){
            throw new IllegalStateException("the email is not valid");
        }
        ArrayList<NormalUser> userName =
                normalUserRepository.findNormalUserByUserName(normalUser.getUserName());
        if(!userName.isEmpty()){
            throw new IllegalStateException("the username already exists");
        }
        normalUserRepository.save(normalUser);
    }

    public void deleteNormalUser(Long id) {
        if(!normalUserRepository.existsById(id)){
            throw new IllegalStateException("user with id "+id+" does not exists");
        }
        normalUserRepository.deleteById(id);
    }
    @Transactional
    public void updateNormalUser(Long id, String userName, String password,
                                 String email,Integer rating) {
        NormalUser normalUser = normalUserRepository.findNormalUserByID(id);
        if(normalUser == null){
            throw new IllegalStateException("the user with id "+id+" doesn't exist");
        }

        if(userName !=null&&userName.length()>0&&!normalUser.getUserName().equals(userName)){
            if(!normalUserRepository.findNormalUserByUserName(userName).isEmpty()){
                throw new IllegalStateException("the username already exists");
            }
            normalUser.setUserName(userName);
        }

        if(password !=null&&password.length()>0&&!normalUser.getPassWord().equals(password)){
            normalUser.setPassword(password);
        }
        //email need more modification
        if(email !=null&&email.length()>0&&!normalUser.getEmail().equals(email)){
            ArrayList<NormalUser> userByEmail =
                    normalUserRepository.findNormalUserByEmail(email);
            if(!userByEmail.isEmpty()){
                throw new IllegalStateException("the email already exist");
            }
            if(!EmailValidator.getInstance(true).isValid(email)){
                throw new IllegalStateException("the email is not valid");
            }
            normalUser.setEmail(email);
        }

        if(rating !=null&&rating>=0&&!normalUser.getRating().equals(rating)) {
            normalUser.setRating(rating);
        }
    }


    public void ActivateAccount(String email, String code) {
        NormalUser normalUser = normalUserRepository.findNormalUserByEmail(email).get(0);
        //normalUserRepository.delete(normalUser);
        System.out.println("Karen break up "+normalUser.getUserName());
        if(normalUser == null){
            throw new IllegalStateException("the user with id "+email+" doesn't exist");
        }
        if(code.equals(normalUser.getVerificationCode())){
            normalUser.setIsActivated(true);
            normalUserRepository.save(normalUser);
        }else{
            throw new IllegalStateException("the verification code doesn't match");
        }
    }
}
