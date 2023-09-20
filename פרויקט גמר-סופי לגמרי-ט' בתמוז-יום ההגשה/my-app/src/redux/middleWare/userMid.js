import axios from "axios";
const url = 'http://localhost:999/myUser/';

export const middlewareUSERFunctions = ({ dispatch, getState }) => next => action => {
    debugger
    if (action.type == 'GET_USER_BY_MAIL_AND_PASSWORD') {
        const getUSERmailPassord = async () => {
            debugger
            let mail = action.payload.mail
            let password = action.payload.password
            action.payload = null
            action.payload = await (await axios.get(`https://localhost:7182/api/User/SignIn?mail=${mail}&password=${password}`)).data
           debugger
           
            return next(action)
        }
        getUSERmailPassord()
    }
    if (action.type == 'ADD_USER') {
        const addUser = async () => {
            const user = await (await axios.put(`${url}/add`, action.payload))
            action.payload = user.data
            return next(action)
        }
        addUser()
    }
    if (action.type == 'GET_ALL_USER') { 
        const getAll = async () => {
            const allUser = await (await axios.get(`${url}/getAll`))
            action.payload = allUser.data
            return next(action)
        }
        getAll()
    }
  

    if (action.type == 'DELETE_USER') {
        debugger
        const deleteUser = async () => {
            const allUser = await (await axios.delete(`${url}/dell/${action.payload.name}/${action.payload.password}`))
            action.payload = allUser.data
            return next(action)
        }
        deleteUser()
    }
    if (action.type == 'ADD_LOVE_RECIPY') {
        debugger        
        const addloveR=async()=>{
            debugger
            let r=await axios.post(`http://localhost:1234/myUser/AddRecipy/${action.payload.id}`,action.payload)
            debugger
            action.payload=r.data
            return next(action)
        }
        addloveR()
    }
    if (action.type == 'DELETE_RECIPY_FROM_USER') {
        debugger        
        const deleteRecipyFromUser=async()=>{
            debugger
            let r=await axios.post(`http://localhost:1234/myUser/deleteRecipyFromUser/${action.payload.id}`,action.payload)
            debugger
            action.payload=r.data
            return next(action)
        }
        deleteRecipyFromUser()
    }
    return next(action)
}