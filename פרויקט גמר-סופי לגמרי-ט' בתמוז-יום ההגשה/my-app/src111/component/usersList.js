import React, { useEffect } from "react";
import { useSelector, useDispatch } from 'react-redux'
import { deleteUser, getAllUser } from "../redux/action";

export default function UserList() {

    const dispatch = useDispatch()
    const users = useSelector(state => state.userR.userList)

    useEffect(() => {
        debugger
        dispatch(getAllUser())
    }, [])

    function del(u) {
        let y = { name: u.name, password: u.password };
        dispatch(deleteUser(y))
    }

    return <>
hhh
        {users && users.map((u) => {
            return (
                <>
                    <div className="column" style={{ backgroundColor: "black", width: '20%', height: '50%', margin: '2%', display: 'inline-block' }}>
                        <h1 style={{ color: "deeppink" }}>{u.name}</h1>
                        <p>name:    {u.name}</p>
                        <p>password:     {u.password}</p>
                        <p>address:   {u.adress}</p>
                        <p>phone:    {u.phone}</p>
                        {/* {u._id} */}
                        {u.matcon && u.matcon.map((r) => {
                            return <>
                                <div style={{ backgroundColor: "pink", borderRadius: "80px" }}>
                                    <><br /><h5 style={{ color: "deeppink" }}>{r.name}</h5>
                                        <h6>  <p>{r.pic}</p>
                                            <p>describe:   {r.describe}</p>
                                            <p>rama:    {r.rama}</p>
                                            <p>time:    {r.time} min</p>
                                            <p>sog:    {r.sog}</p>
                                            <p>password:   {r.password}</p>
                                            <p style={{ color: "rebeccapurple" }}>---- 🛒:racivim:🛒----</p>
                                            <p>{r.raciv && r.raciv.map((r1) => {
                                                return <>
                                                    <p style={{ color: "Highlight" }}> {r1.nameR} :  {r1.amount} </p>
                                                </>
                                            })
                                            } </p>
                                        </h6>
                                        <br />
                                    </>
                                </div>
                            </>
                        })
                        }
                        <button onClick={() => del(u)}>מחיקה</button>
                    </div>
                </>)
        })}
    </>
}