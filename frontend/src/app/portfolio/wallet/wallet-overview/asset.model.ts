export type Asset = {
  id: string,
  name: string,
  quantity: number,
  buyingPrice: number,
  currency: string,
  timestamp: string
}

export type CreateAssetRequest = {
  walletId: number,
  name: string,
  quantity: number,
  buyingPrice: number,
  currency: string
}
