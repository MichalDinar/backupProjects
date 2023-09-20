import { useAuthContext } from "./useAuthContext"
import { Navigate } from 'react-router-dom'

export default function RoleGuard({ children }) {
    const { user, isAuthenticated } = useAuthContext()

    if (!isAuthenticated) {
        return <Navigate to='/SignIn' />
    }

    if (user.userType == 1) {
        return <h1>אין לך גישה לדף זה!</h1>
    }

    return children
}