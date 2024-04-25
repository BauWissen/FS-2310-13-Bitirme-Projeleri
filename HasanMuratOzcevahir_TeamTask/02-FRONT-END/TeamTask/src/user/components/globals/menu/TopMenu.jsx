import React from 'react'
import { useSelector } from 'react-redux'
import { Link } from 'react-router-dom'
import IconGenerator from '../../../../utilities/IconGenerator'

const TopMenu = () => {
    const user = useSelector((state) => state.currentUser.user)
    console.log(user, " user from topmenu")
    return (

        user == null ? <div className='p-4 text-2xl text-slate-400 bg-zinc-800 gap-5 flex justify-between w-full items-center'> 
         <span className='text-orange-400 w-full'>Team Task</span>
        <div className='p-4 text-2xl text-slate-300 gap-5 flex w-full justify-end'>
           
            <Link to="/login" className='p-4 rounded-xl shadow-xl hover:bg-orange-100 transition-all duration-300'>Giriş</Link>
            <Link to="/signup" className='p-4 bg-orange-400 rounded-xl shadow-xl hover:bg-orange-100 transition-all duration-300'>Kaydol</Link>
        </div>
        </div>
            :
            <div className='p-4 text-2xl text-slate-400 bg-zinc-800 gap-5 flex justify-between w-full items-center'>
                <span className='text-4xl font-semibold'> Tekrar hoş geldin, {user.user.firstName}</span>
                <div className='flex gap-5 items-center'>
                    <small className='text-rose-500  hover:text-rose-600 transition-all duration-300 cursor-pointer'>çıkış</small>
                    <Link className='p-4 bg-orange-400 bg-gradient-to-l from-orange-400 to-sky-300 rounded-full text-zinc-700 font-semibold hover:shadow-xl hover:scale-95 transition-all duration-100' to="/dashboard"><span>Çalışma alanın</span> <IconGenerator name="fa-solid fa-arrow-right-to-bracket" /></Link>
                </div>
            </div>


    )
}

export default TopMenu