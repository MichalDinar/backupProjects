import React, { useEffect, useState } from "react";
import { useSelector, useDispatch } from 'react-redux'
import { useNavigate } from "react-router-dom";
import { addLoveRecipy, addRecipy, deleteRecipy, getAllRecipy } from "../redux/action";
import AddRecipy from "./addRecipy";
import Details from "./details";

export default function RecipyList() {
    const dispatch = useDispatch()
    const n=useNavigate()
    const recipy = useSelector(state => state.recipyR.recipyList)
    const Manger = useSelector(state => state.userR.isManger)
    const name = useSelector(state => state.userR.user.name)
    const user = useSelector(state => state.userR.user)

    const [edit, setEdit] = useState(false)
    const [add, setAdd] = useState(false)
    const [id, setId] = useState(null)
    const [details, setDetails] = useState(false)
    useEffect(() => {
        debugger
        dispatch(getAllRecipy())
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
    function loveRecipy(e, r) {
        debugger
        let y = e.currentTarget.checked;
        if (y) {
            let user1 = {
                id: user._id, name: user.name, password: user.password, adress: user.adress, phone: user.phone, isManger: user.isManger,
                matcon: user.matcon.concat(r)
            };
            dispatch(addLoveRecipy(user1))
        }
        // אי אפשר למחוק דרך כאן אלא רק באזור האישי
        else {
            //למחוק מהמערך שלו 
        }
    }
    return (
        <>
            בס"ד
            <h1>:🍧🍨🍩🍪🧁המתכונים שלנו</h1>
            {Manger &&<>
                    {!add?
                    <button onClick={() => setAdd(true)}>הוספת מתכון</button>:
                    <AddRecipy add={setAdd}></AddRecipy>}
                    </>
            }
            {recipy && recipy.map((r) => {
                return (
                    <>
                        <div class="column" style={{ backgroundColor: "pink", borderRadius: "70px" }}>
                            {/* <div style={{ width: '20', height: '70px', margin: '2%', display: 'inline-block', float:"center"  }}> */}
                            {id != r._id &&
                                <>   <h1 style={{ color: "deeppink" }}>{r.name}</h1>
                                    ------------------------------
                                    <p>{r.pic}</p>  ------------------------------
                                    <button onClick={() => { deta(r.id?r.id:r._id) }}>לפרטים נוספים</button>
                                    {/* <p>describe:   {r.describe}</p>
                                    <p>rama:    {r.rama}</p>
                                    <p>time:    {r.time} min</p>
                                    <p>sog:    {r.sog}</p>
                                    <p>password:   {r.password}</p>
                                    {r._id}*/}
                                    <p style={{ color: "rebeccapurple" }}>---- 🛒:racivim:🛒----</p>
                                    <p>{r.raciv && r.raciv.map((r1) => {
                                        return (
                                            <p style={{ color: "Highlight" }}> {r1.nameR} :  {r1.amount} </p>
                                        )
                                    })
                                    } </p> 
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
                            {Manger && ((id ==(r.id?r.id:r._id)  && details ) || id!=(r.id?r.id:r._id)) &&
                                <>
                                    <button onClick={() => deleteR(r.id?r.id:r._id)}>מחיקה</button>
                                    <button onClick={() => editR(r.id?r.id:r._id)}>עריכה</button>
                                </>
                            }
                            {!Manger && name &&
                                <>
                                    <h1 style={{ color: "red" }}><input type="checkbox" onClick={(e) => loveRecipy(e, r)} />??אוהב</h1>
                                </>

                            }
                        </div>
                    </>
                )

            })}
        </>)

}