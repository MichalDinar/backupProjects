import React, {  useState } from "react";
import { useSelector, useDispatch } from 'react-redux'
import { deleteRecipyFromUser } from "../redux/action";
import AddRecipy from "./addRecipy";
import Details from "./details";

export default function RecipyListPersonal() {
    const dispatch = useDispatch()
    const recipy = useSelector(state => state.userR.user.matcon)
    const [edit, setEdit] = useState(false)
    const [id, setId] = useState(false)
    const [details, setDetails] = useState(false)
    const user = useSelector(state => state.userR.user)

    function deleteRFromuser(id) {
        debugger
        let user1 = {
            id: user._id?user._id:user.id, name: user.name, password: user.password, adress: user.adress, phone: user.phone, isManger: user.isManger,
            matcon: user.matcon.filter(r => r._id != id)
        };
        dispatch(deleteRecipyFromUser(user1))
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
            {recipy && recipy.map((r) => {
                return (
                    <>
                        <div class="column" style={{ backgroundColor: "pink", borderRadius: "70px" }}>
                            {id != (r.id?r.id:r._id) &&
                                <>   <h1 style={{ color: "deeppink" }}>{r.name}</h1>
                                    ------------------------------
                                    <p>{r.pic}</p>  ------------------------------
                                    <button onClick={() => { deta(r.id?r.id:r._id) }}>לפרטים נוספים</button>
                                    <br></br>
                                    {/* <p>describe:   {r.describe}</p>
                                    <p>rama:    {r.rama}</p>
                                    <p>time:    {r.time} min</p>
                                    <p>sog:    {r.sog}</p>
                                    <p>password:   {r.password}</p> 
                                    {r.id}
                                    <p style={{ color: "rebeccapurple" }}>---- 🛒:racivim:🛒----</p>
                                    <p>{r.raciv && r.raciv.map((r1) => {
                                        return <>
                                            <p style={{ color: "Highlight" }}> {r1.nameR} :  {r1.amount} </p>
                                        </>
                                    }) 
                                    } </p>*/}
                                </>}
                            {id == (r.id?r.id:r._id) && details && <>
                                <Details r={r}></Details>
                                <button onClick={() => { deta(null) }}>לסגור פרטים נוספים</button>
                            </>}
                            {edit && id == (r.id?r.id:r._id) &&
                                <>
                                    <h2>עריכה</h2>
                                    <AddRecipy recipyPersonal={true} id={r.id?r.id:r._id} name={r.name} pic={r.pic} describe={r.describe} rama={r.rama} time={r.time} sog={r.sog} password={r.password} arrR={r.raciv} edite={edit} setId={setId} setEdit={setEdit}></AddRecipy>
                                </>
                            }
                            <br></br>
                            {((id == (r.id?r.id:r._id) && details ) || id!=(r.id?r.id:r._id)) &&
                                <>
                                    <button onClick={() => deleteRFromuser(r.id?r.id:r._id)}>מחיקה</button>
                                    <button onClick={() => editR(r.id?r.id:r._id)}>עריכה</button>
                                </>} </div>
                    </>
                )
            })}
        </>)
}