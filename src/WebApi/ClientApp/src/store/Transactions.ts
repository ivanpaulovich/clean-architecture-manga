import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

export interface TransactionsState {
    transactions: Transaction[];
}

export interface Transaction {
    transactionId: string;
    amount: number;
    description: string;
    transactionDate: Date;
}

interface RequestTransactionsAction {
    type: 'REQUEST_TRANSACTIONS';
}

interface ReceiveTransactionsAction {
    type: 'RECEIVE_TRANSACTIONS';
    transactions: Transaction[];
}

type KnownAction = RequestTransactionsAction | ReceiveTransactionsAction;

export const actionCreators = {
    requestTransactions: (accountId: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        fetch(`api/v1/Transactions/{accountId}`)
            .then(response => response.json() as Promise<Transaction[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_TRANSACTIONS', transactions: data });
            });
    }
};

const unloadedState: TransactionsState = { transactions: [] };

export const reducer: Reducer<TransactionsState> = (state: TransactionsState | undefined, incomingAction: Action): TransactionsState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'RECEIVE_TRANSACTIONS':
            return {
                transactions: action.transactions
            };
            break;
    }

    return state;
};
