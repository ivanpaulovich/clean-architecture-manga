import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as LoginStore from '../store/Logins';

type LoginProps =
    LoginStore.LoginState &
    typeof LoginStore.actionCreators &
    RouteComponentProps<{}>;

class FetchLogin extends React.PureComponent<LoginProps> {
  public render() {
      return (
        <React.Fragment>
          <button>Logout</button>
        </React.Fragment>
      );
  }
}

export default connect(
  (state: ApplicationState) => state.login,
  LoginStore.actionCreators
)(FetchLogin as any);
