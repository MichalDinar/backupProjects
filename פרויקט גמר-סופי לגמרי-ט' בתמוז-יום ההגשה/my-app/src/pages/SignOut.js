import { useDispatch, useSelector } from 'react-redux'
import { Navigate } from 'react-router-dom'
import { signOut } from '../redux/action'
// import { useAuthContext } from "./useAuthContext"

export default function SignOut() {
    const dispatch = useDispatch()
    const userId = useSelector(state => state.userR.userId)
    const userType = useSelector(state => state.userR.userType)
    const user={
        userId:userId,
        userType:userType
    }
        
    const a=()=>{
        debugger
        dispatch(signOut(user))
        console.log(" ");
    }

    return <>a</>
}