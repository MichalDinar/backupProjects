
export function getAllUser(user)
{
    return {type:"GET_ALL_USER",payload:user}
}
export function addUser(user)
{
    return {type:"ADD_USER",payload:user}
}



export function getUSERmailPassord(user)
{
    return {type:"GET_USER_BY_MAIL_AND_PASSWORD",payload:user}
}
export function signOut(user)
{
    return {type:"SIGN_OUT",payload:user}
}
export const logout = () => ({
    type: 'LOGOUT',
  });


export function deleteUser(user)
{
    return {type:"DELETE_USER",payload:user}
}
