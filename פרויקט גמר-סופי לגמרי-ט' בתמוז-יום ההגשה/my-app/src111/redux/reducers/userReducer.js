import produce from 'immer';

const initialState = {
    userList: [],
    user: {},
    isManger: "",
    userType:0,
    userId:0,
}

export default produce((state, action) => {
    debugger
    switch (action.type) {
        case 'GET_USER_BY_NAME_AND_PASSWORD':
            state.userType = action.payload?.userType;
            state.userId = action.payload?.userId;
            break;
        case 'ADD_USER':
            state.userList.push(action.payload);
            state.user = action.payload;
            break;
        case 'GET_ALL_USER':
            state.userList = action.payload;
            break;
        case 'DELETE_USER':
            state.userList = state.userList.filter(i => (!(i.password == action.payload.password && i.name == action.payload.name)));
            break;
        case 'ADD_LOVE_RECIPY':
            state.user = action.payload;
            break;
        case 'DELETE_RECIPY_FROM_USER':
            state.user = action.payload;
            break;
    }
}, initialState
)