import { useContext } from "react";
import { AuthContext } from './AuthContext'

export  function useAuthContext() {
    const context = useContext(AuthContext)

    if (!context) {
        throw new Error('AuthContext can not be used outside AuthProvider')
    }

    return context
}
