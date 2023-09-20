import React, { useEffect, useState } from "react";
import { useSelector, useDispatch } from 'react-redux'
import { deleteRecipy, deleteRecipyFromUser, getAllRecipy } from "../redux/action";
import AddRecipy from "./addRecipy";
import Details from "./details";

export default function MyRecipyAdd() {

    const dispatch = useDispatch()
    const recipy = useSelector(state => state.recipyR.recipyList)
    const [edit, setEdit] = useState(false)
    const [myRecipy, setmyRecipy] = useState([])
    const [id, setId] = useState(false)
    const [details, setDetails] = useState(false)
    const user = useSelector(state => state.userR.user)

    useEffect(() => {
        if (!recipy[0])
            dispatch(getAllRecipy())
        setmyRecipy(recipy.filter(i => i.userId == (user.id ? user.id : user._id)))
        debugger
    }, [])
    function deleteR(id) {
        debugger
        dispatch(deleteRecipy(id))
    }
    function editR(id1) {
        setDetails(false)
        setEdit(true)
        setId(id1)
    }
    function deta(id1) {
        setEdit(false)
        if (id1) {
            setId(id1)
            setDetails(true)
        }
        else {
            setId(null)
            setDetails(false)
        }
    }
    return (
        <>
            בס"ד
            <h1>:🍧🍨🍩🍪🧁המתכונים שלנו</h1>
            {myRecipy && myRecipy.map((r) => {
                return (
                    <>
                        <div class="column" style={{ backgroundColor: "pink", borderRadius: "70px" }}>
                            {id != (r.id ? r.id : r._id) &&
                                <>   <h1 style={{ color: "deeppink" }}>{r.name}</h1>
                                    ------------------------------
                                    <p>{r.pic}</p>  ------------------------------
                                    <button onClick={() => { deta(r.id ? r.id : r._id) }}>לפרטים נוספים</button>
                                    <br></br>
                                </>}
                            {id == (r.id ? r.id : r._id) && details && <>
                                <Details r={r}></Details>
                                <button onClick={() => { deta(null) }}>לסגור פרטים נוספים</button>
                            </>}
                            {edit && id == (r.id ? r.id : r._id) &&
                                <>
                                    <h2>עריכה</h2>
                                    <AddRecipy recipyPersonal={true} id={r.id ? r.id : r._id} name={r.name} pic={r.pic} describe={r.describe} rama={r.rama} time={r.time} sog={r.sog} password={r.password} arrR={r.raciv} edite={edit} setId={setId} setEdit={setEdit}></AddRecipy>
                                </>
                            }
                            <br></br>
                            {((id == (r.id ? r.id : r._id) && details) || id != (r.id ? r.id : r._id)) &&
                                <>
                                    <button onClick={() => deleteR(r.id ? r.id : r._id)}>מחיקה</button>
                                    <button onClick={() => editR(r.id ? r.id : r._id)}>עריכה</button>
                                </>} </div>
                    </>
                )
            })}
        </>)
}