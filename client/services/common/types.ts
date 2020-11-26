export enum Status {
  OK = 200,
  BadRequest = 400,
  NotFound = 404,
}

export enum RequestMethod {
  GET = 'GET',
  POST = 'POST',
  PUT = 'PUT',
  DELETE = 'DELETE',
  PATCH = 'PATCH',
}

// ------------------------------------------------------------------------- //

export interface IRequestParams {
  method?: RequestMethod;
  url: string;
  headers?: Headers;
}

// ? maybe we should pass generic param
export interface IRequestWithBodyParams extends IRequestParams {
  contentType: string;
  body: any;
}

// ------------------------------------------------------------------------- //

export abstract class Result {
  public constructor(public readonly status: Status) {}
}

export class ObjectResult extends Result {
  public constructor(
    public readonly status: Status,
    // eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
    public readonly body: any
  ) {
    super(status);
  }
}

export class ErrorResult extends Result {
  public constructor(
    public readonly status: Status,
    // eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
    public readonly error: any
  ) {
    super(status);
  }
}
