import { HttpInterceptorFn, HttpRequest, HttpHandlerFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { AuthService } from "./auth.service";

export const authenticationInterceptor: HttpInterceptorFn = (req: HttpRequest<unknown>, next:
HttpHandlerFn) => {
  const authService = inject(AuthService);
  const userData = authService.getUserData(); 
  
  if(!userData) {
    return next(req);
  }

  const modifiedReq = req.clone({
    headers: req.headers.set('Authorization', `Bearer ${userData.token}`),
  });
  return next(modifiedReq);
};
