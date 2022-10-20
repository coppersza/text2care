export interface IToken {
  tokenUID: string;
  tokenName: string;
  donatorName: string;
  donatorEmail: string,
  storeName: string;
  productType: string;
  productName: string;
  recipientName: string;
  costPrice: number;
  salesPrice: number;
  dateCreated: Date;
  dateStoreAssigned: Date;
  dateAssigned: Date;
  dateCollected: Date;
  dateRelease: Date;
  dateExpire: Date;
  foodCollected: boolean;
  valid: boolean;
  imageUrl: string;
  shortUrl: string;
}