"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.actionCreators = {
    requestDisplayItems: function (param) { return function (dispatch, getState) {
        // Only load data if it's something we don't already have (and are not already loading)
        var appState = getState();
        fetch('/api/Person/GetPersons?type=' + param)
            .then(function (response) { return response.json(); })
            .then(function (data) {
            dispatch({ type: 'RECEIVE_DISPLAY_ITEMS', displayItems: data });
        });
        dispatch({ type: 'REQUEST_DISPLAY_ITEMS' });
    }; }
};
var unloadedState = { displayItems: [], isLoading: false };
exports.reducer = function (state, incomingAction) {
    if (state === undefined) {
        return unloadedState;
    }
    var action = incomingAction;
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
//# sourceMappingURL=DisplayItems.js.map