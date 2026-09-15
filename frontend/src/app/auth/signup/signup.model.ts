export type SignupModel = {
  email: string,
  password: string,
  role: 'None' | 'Basic' | 'Pro' | 'Administrator'
}
