import { Role } from "../role.model"

export type SignupModel = {
  email: string,
  password: string,
  role: Role
}
