import { useSelector } from 'react-redux'
import { Navigate } from 'react-router-dom'
// import { useAuthContext } from "./useAuthContext"

export default function AuthGuard({ children }) {
    // const { isAuthenticated } = useAuthContext()
    const userId = useSelector(state => state.userR.userId)


    if (!userId) {
        return <Navigate to='/SignIn' />
    }

    return children
}