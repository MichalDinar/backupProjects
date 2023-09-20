debugger
export function getAllRecipy(recipy)
{
    return {type:"GET_ALL_RECIPY",payload:recipy}
}
export function getAllUser(user)
{
    return {type:"GET_ALL_USER",payload:user}
}
export function addUser(user)
{
    return {type:"ADD_USER",payload:user}
}
export function getUSERNamePassord(user)
{
    return {type:"GET_USER_BY_NAME_AND_PASSWORD",payload:user}
}
export function deleteUser(user)
{
    return {type:"DELETE_USER",payload:user}
}
export function deleteRecipy(idRecipy)
{
    return {type:"DELETE_RECIPY",payload:idRecipy}
}
export function addRecipy(recipy)
{
    return {type:"ADD_RECIPY",payload:recipy}
}
export function editRecipy(recipy)
{
    return {type:"EDIT_RECIPY",payload:recipy}
}
export function addLoveRecipy(recipy)
{
    return {type:"ADD_LOVE_RECIPY",payload:recipy}
}
export function deleteRecipyFromUser(user)
{
    return {type:"DELETE_RECIPY_FROM_USER",payload:user}
}
