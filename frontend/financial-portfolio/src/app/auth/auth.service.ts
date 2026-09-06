import { Service } from "@angular/core";

@Service()
export class AuthService {
  login(email: string, password: string) {
    console.log(email, password);
  }
}
