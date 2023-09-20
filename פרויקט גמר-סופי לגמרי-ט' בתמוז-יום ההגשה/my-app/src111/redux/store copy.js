import {combineReducers,applyMiddleware,createStore} from 'redux'
import { middlewareRECIPYFunctions } from './middleWare/recipyMid'
import { middlewareUSERFunctions } from './middleWare/userMid'
import recipyR from './reducers/recipyReducer'
import userR from './reducers/userReducer'
debugger
const myReducer=combineReducers({recipyR,userR})
const myMiddleware=applyMiddleware(middlewareRECIPYFunctions,middlewareUSERFunctions)
const store=createStore(myReducer,myMiddleware)
window.store=store;
export default store;

