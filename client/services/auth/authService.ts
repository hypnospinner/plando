import { Service } from '@services/common/service';
import {
  Result,
  IRequestWithBodyParams,
  ObjectResult,
  Status,
} from '@services/common/types';

class AuthService extends Service {
  public login(username: string, password: string): Promise<Result> {
    const url = '';

    return Promise.resolve(new ObjectResult(Status.OK, 'token'));

    return this.post({
      url,
      contentType: 'application/json',
      body: { username, password },
    } as IRequestWithBodyParams);
  }
}

export default AuthService;
