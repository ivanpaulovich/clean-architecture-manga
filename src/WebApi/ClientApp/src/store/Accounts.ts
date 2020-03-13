import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

export interface AccountsState {
    accounts: Account[];
}

export interface Account {
    accountId: string;
    currentBalance: number;
}

interface RequestAccountsAction {
    type: 'REQUEST_ACCOUNTS';
}

interface ReceiveAccountsAction {
    type: 'RECEIVE_ACCOUNTS';
    accounts: Account[];
}

type KnownAction = RequestAccountsAction | ReceiveAccountsAction;

export const actionCreators = {
    requestAccounts: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        fetch(`api/v1/accounts`)
            .then(response => response.json() as Promise<Account[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_ACCOUNTS', accounts: data });
            });
    }
};

const unloadedState: AccountsState = { accounts: [] };

export const reducer: Reducer<AccountsState> = (state: AccountsState | undefined, incomingAction: Action): AccountsState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'RECEIVE_ACCOUNTS':
            return {
                accounts: action.accounts
            };
            break;
    }

    return state;
};
