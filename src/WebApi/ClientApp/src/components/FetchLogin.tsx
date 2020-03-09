import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as LoginStore from '../store/Logins';

type LoginProps =
  LoginStore.LoginState
  & typeof LoginStore.actionCreators;


class FetchLogin extends React.PureComponent<LoginProps> {
  public componentDidMount() {
    this.ensureDataFetched();
  }

  public componentDidUpdate() {
    this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
          <li>{this.props.isLoading}a</li>
      </React.Fragment>
    );
  }

  private ensureDataFetched() {
    this.props.requestLogin();
  }
}

export default connect(
  (state: ApplicationState) => state.login,
    LoginStore.actionCreators
)(FetchLogin as any);
