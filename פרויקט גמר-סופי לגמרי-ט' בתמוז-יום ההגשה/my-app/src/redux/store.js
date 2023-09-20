import {combineReducers,applyMiddleware,createStore} from 'redux'
import { middlewareUSERFunctions } from './middleWare/userMid'
import userR from './reducers/userReducer'
debugger
const myReducer=combineReducers({userR})
const myMiddleware=applyMiddleware(middlewareUSERFunctions)
const store=createStore(myReducer,myMiddleware)
window.store=store;
export default store;

