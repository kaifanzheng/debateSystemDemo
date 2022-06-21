package com.DebateSystem1111111.demo;


import com.DebateSystem1111111.demo.DAO.NormalUserRepository;
import com.DebateSystem1111111.demo.modle.NormalUser;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;


@SpringBootApplication
public class DebateSystemApplication {

	public static void main(String[] args) {
		SpringApplication.run(DebateSystemApplication.class, args);
	}

	@Bean
	CommandLineRunner commandLineRunner(NormalUserRepository normalUserRepository){
		return args ->{
			normalUserRepository.save(new NormalUser("zhengkaifan@qq.com","zkf20001212","bbking73",6));
			normalUserRepository.save(new NormalUser("n.saiyaraxd@qq.com","Noshin20021220","bbqueen73",6));
		};
	}



}
