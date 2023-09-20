import { createContext, useState } from "react";
import { login as loginApi } from '../service/user.service'

export const AuthContext = createContext(null)


export default function AuthProvider({ children }) {
    const [isAuthenticated, setIsAuthenticated] = useState(false)
    const [user, setUser] = useState(false)

    const login = async (email,password,userType,userId) => {
        console.log("authContext "+email+password)
        const user = await loginApi(email,password)
        user.userType=userType;
        user.userId=userId
        setIsAuthenticated(true)
        setUser(user)
        console.log("user connected: "+user.userId+"- "+user.userType)
        console.log(user);
    }

    return <AuthContext.Provider value={{ login, isAuthenticated, user }}>
        {children}
    </AuthContext.Provider>
}