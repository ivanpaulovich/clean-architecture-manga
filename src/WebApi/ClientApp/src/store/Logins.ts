import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

export interface LoginState {
    isLoggedIn: boolean;
}

interface ReceiveLoginAction {
    type: 'RECEIVE_LOGIN';
    isLoggedIn: boolean;
}

export const actionCreators = {
    requestLogin: (): AppThunkAction<ReceiveLoginAction> => (dispatch) => {
        dispatch({type: 'RECEIVE_LOGIN', isLoggedIn: true});
    }
};

export const reducer: Reducer<LoginState> = (state: LoginState | undefined, incomingAction: Action): LoginState => {
    if (state === undefined) {
        return { isLoggedIn: false };
    }

    const action = incomingAction as ReceiveLoginAction;

    switch(action.type) {
        case 'RECEIVE_LOGIN':
            return {
                isLoggedIn: true,
            };

        default:
            return state;
    }
};
