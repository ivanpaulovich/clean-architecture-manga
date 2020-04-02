import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

export interface TransactionsState {
    transactions: Transactions;
}

export interface Transactions {
    credits: Credit[];
    debits: Debit[];
}

export interface Credit {
    transactionId: string;
    amount: number;
    description: string;
    transactionDate: Date;
}

export interface Debit {
    transactionId: string;
    amount: number;
    description: string;
    transactionDate: Date;
}

interface ReceiveTransactionsAction {
    type: 'RECEIVE_TRANSACTIONS';
    transactions: Transactions;
}

export const actionCreators = {
    requestTransactions: (accountId: string): AppThunkAction<ReceiveTransactionsAction> => (dispatch, getState) => {
        fetch(`api/v1/Accounts/${accountId}`)
            .then(response => response.json() as Promise<Transactions>)
            .then(data => {
                dispatch({ type: 'RECEIVE_TRANSACTIONS', transactions: data });
            });
    }
};

const unloadedState: TransactionsState = { transactions: { credits: [], debits: [] } };

export const reducer: Reducer<TransactionsState> = (state: TransactionsState | undefined, incomingAction: Action): TransactionsState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as ReceiveTransactionsAction;
    switch (action.type) {
        case 'RECEIVE_TRANSACTIONS':
            return {
                transactions: action.transactions
            };
            break;
    }

    return state;
};
