import {
  IRequestParams,
  IRequestWithBodyParams,
  Result,
  ObjectResult,
  ErrorResult,
  RequestMethod,
} from '@services/common/types';

// about env variables in nextjs
// https://stackoverflow.com/questions/59462614/how-to-use-diferent-env-files-with-nextjs

export abstract class Service {
  protected baseUrl: string;
  protected baseParams: any;

  public constructor() {
    const BASE_URL = process.env.BASE_URL;

    if (!BASE_URL) throw new Error("Can't resolve BASE_URL");

    this.baseUrl = BASE_URL;
    this.baseParams = {};

    // eslint-disable-next-line no-console
    console.log(this.baseUrl);
  }

  private static getRequestInit(params: IRequestParams): RequestInit {
    const requestInit: RequestInit = {};

    requestInit.headers = Service.getHeaders(params);
    requestInit.method = params.method;
    requestInit.cache = 'default';

    if ('contentType' in params) {
      requestInit.body = Service.getBody(params);
    }

    return requestInit;
  }

  private static getBody(
    params: IRequestWithBodyParams
  ):
    | string
    | Blob
    | ArrayBufferView
    | ArrayBuffer
    | FormData
    | URLSearchParams
    | ReadableStream<Uint8Array>
    | null
    | undefined {
    switch (params.contentType) {
      case 'application/json':
        return JSON.stringify(params.body);
      default:
        throw new Error("Can't convert to this body type");
    }
  }

  private static getHeaders(params: IRequestParams): Headers {
    const { headers: headersFromParams } = params;
    const headers = new Headers(headersFromParams);

    const token = localStorage.getItem('token');

    if (token) {
      headers.append('Authorization', token);
    }

    if ('contentType' in params) {
      headers.append(
        'Content-Type',
        (params as IRequestWithBodyParams).contentType
      );
    }

    return headers;
  }

  private handleRequest(params: IRequestParams): Promise<Result> {
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    return new Promise((_resolve, _reject) => {
      fetch(`${this.baseUrl}/`, Service.getRequestInit(params)).then(
        (_response: Response) => {
          _response.json().then((body: any) => {
            let result: Result;

            if (_response.ok) {
              result = new ObjectResult(_response.status, body.data);
            } else {
              result = new ErrorResult(_response.status, body.error);
            }

            return result;
          });
        }
      );
    });
  }

  protected get(params: IRequestParams): Promise<Result> {
    return this.handleRequest({ ...params, method: RequestMethod.GET });
  }

  protected post(params: IRequestParams): Promise<Result> {
    return this.handleRequest({ ...params, method: RequestMethod.POST });
  }

  protected put(params: IRequestParams): Promise<Result> {
    return this.handleRequest({ ...params, method: RequestMethod.PUT });
  }

  protected patch(params: IRequestParams): Promise<Result> {
    return this.handleRequest({ ...params, method: RequestMethod.PATCH });
  }

  protected delete(params: IRequestParams): Promise<Result> {
    return this.handleRequest({ ...params, method: RequestMethod.DELETE });
  }
}
