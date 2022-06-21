package com.DebateSystem1111111.demo.Controller;
import com.DebateSystem1111111.demo.Service.NormalUserService;
import com.DebateSystem1111111.demo.modle.NormalUser;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping(path = "api/v1/NormalUser")
public class NormalUserController {
    private final NormalUserService normalUserService;

    @Autowired
    public NormalUserController(NormalUserService normalUserService) {
        this.normalUserService = normalUserService;
    }

    @GetMapping("/all")
    public List<NormalUser> getNormalUsers(){
        return normalUserService.getNormalUsers();
    }

    @GetMapping("/find/{ID}")
    public NormalUser getNormalUserByID(@PathVariable("ID") Long id){
        return normalUserService.getNormalUserByID(id);
    }

    @PostMapping("/add")
    public void registerNewNormalUser(@RequestBody NormalUser normalUser){
        normalUserService.addNormalUser(normalUser);
    }
    @PutMapping("/activateAccount/{email}")
    public void activateAccount(@PathVariable("email") String email, 
                                @RequestParam String verificationCode){
        System.out.println("I love Noshin "+email);
        normalUserService.ActivateAccount(email,verificationCode);
    }
    @DeleteMapping( "/delete/{NormalUserID}")
    public void deleteNormalUser(@PathVariable("NormalUserID") Long ID){
        normalUserService.deleteNormalUser(ID);
    }

    @PutMapping( "/put/{NormalUserID}")
    public void updateNormalUser(@PathVariable("NormalUserID") Long ID,
                                 @RequestParam(required = false) String userName,
                                 @RequestParam(required = false) String password,
                                 @RequestParam(required = false) String email,
                                 @RequestParam(required = false) Integer rating){
        normalUserService.updateNormalUser(ID,userName,password,email,rating);

    }
}
