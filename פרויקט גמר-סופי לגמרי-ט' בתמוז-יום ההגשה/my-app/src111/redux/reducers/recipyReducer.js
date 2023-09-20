import produce from 'immer';

const initialState = {
    recipyList: [],
}
export default produce((state, action) => {
    debugger
    switch (action.type) {
        case 'GET_ALL_RECIPY':
            state.recipyList = action.payload;
            break;
        case 'ADD_RECIPY':
            state.recipyList.push(action.payload);
            break;
        case 'DELETE_RECIPY':
            state.recipyList = state.recipyList.filter(i => i._id != action.payload);
            break;
        case 'EDIT_RECIPY':
            state.recipyList = state.recipyList.filter(i => i._id != action.payload.id);
            debugger
            state.recipyList.push(action.payload);
            break;


    }
}, initialState
)