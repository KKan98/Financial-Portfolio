import { HttpClient } from "@angular/common/http";
import { inject, Service } from "@angular/core";
import { Asset, CreateAssetRequest } from "./asset.model";
import { catchError, throwError } from "rxjs";

@Service()
export class AssetService {
  private httpClient = inject(HttpClient);

  private readonly assetsGetUrl = "https://localhost:44359/api/assets";
  private readonly assetsAddUrl = "https://localhost:44359/api/assets/add"

   get(id: number) {
    return this.httpClient.get<Asset[]>(`${this.assetsGetUrl}/${id}`);
  }

  add(asset: CreateAssetRequest) {
    return this.httpClient.post<CreateAssetRequest[]>(this.assetsAddUrl, asset)
    .pipe(
      catchError((errorRes) => throwError(() => new Error(errorRes.error.detail)))
      );
  }
}
