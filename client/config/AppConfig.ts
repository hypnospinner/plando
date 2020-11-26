class AppConfig {
  private readonly baseApiUrl: string;

  public constructor() {
    if (process.env.NEXT_PUBLIC_BASE_API_URL) {
      this.baseApiUrl = process.env.NEXT_PUBLIC_BASE_API_URL;
    } else {
      throw new Error(
        'NEXT_PUBLIC_BASE_API_URL is not present in your env* file'
      );
    }
  }

  public getBaseApiUrl(): string {
    return this.baseApiUrl;
  }
}

export default AppConfig;
