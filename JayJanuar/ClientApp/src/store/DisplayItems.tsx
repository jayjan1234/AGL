import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';


// -----------------
// STATE - This defines the type of data maintained in the Redux store.
export interface DisplayItem {
    gender: string;
    names: [];
}
export interface DisplayItemState {
    isLoading: boolean;
    startDateIndex?: number;
    displayItems: DisplayItem[];
}

interface ReceiveDisplayItemAction {
    type: 'RECEIVE_DISPLAY_ITEMS';
    displayItems: DisplayItem[];
}

interface RequestDisplayItemAction {
    type: 'REQUEST_DISPLAY_ITEMS';
}


type KnownAction = ReceiveDisplayItemAction | RequestDisplayItemAction;


export const actionCreators = {
    requestDisplayItems: (param: string): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        fetch('/api/Person/GetPersons?type='+ param)
            .then(response => response.json() as Promise<DisplayItem[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_DISPLAY_ITEMS',  displayItems: data });
            });
        dispatch({ type: 'REQUEST_DISPLAY_ITEMS'});
    }
};

const unloadedState: DisplayItemState = { displayItems: [], isLoading: false };

export const reducer: Reducer<DisplayItemState> = (state: DisplayItemState | undefined, incomingAction: Action): DisplayItemState => {
    if (state === undefined) {
        return unloadedState;
    }
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_DISPLAY_ITEMS':
            return {
                displayItems: state.displayItems,
                isLoading: true
            };
        case 'RECEIVE_DISPLAY_ITEMS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action != undefined) {
                return {
                    displayItems: action.displayItems,
                    isLoading: false
                };
            }
            break;

    }
    return state;
};


