import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import TeTaLogo from '../../../../css/logo/logoteta.png'
import { Link, useLocation, useNavigate } from 'react-router-dom'
import { logOut } from '../../../features/user/logOutSlice'
import { removeCurrentUser } from '../../../features/user/loginSlice'
import IconGenerator from '../../../../utilities/IconGenerator'

const TopMenu = ({ user }) => {
    const location = useLocation()
    const dispatch = useDispatch()
    const navigate = useNavigate()
    const handleLogOut = () => {
        dispatch(removeCurrentUser())
        dispatch(logOut())
        // navigate("/")
        window.location.href = "/"
    }

    return (
        <div className='h-max p-2 grid grid-cols-1 lg:grid-cols-3 bg-slate-800 text-white mb-2 border-b-[1px] border-zinc-600 shadow-lg'>

            <div className='flex items-center gap-5'>
               <Link to="/" className='hover:brightness-125 duration-300 transition-all'> <img src={TeTaLogo} width={100} /></Link>

                <span className='lg:tracking-widest text-slate-400 font-normal lg:font-semibold break-all'>{location.pathname.replace("/", "")}</span>

            </div>

            <div className='text-2xl flex lg:justify-center  items-center'>  <span> {user.user.firstName}</span></div>
            <div className='text-2xl flex flex-col lg:flex-row lg:justify-end lg:items-center gap-3'>

                <div onClick={handleLogOut} className='cursor-pointer font-normal text-rose-200 p-2 flex justify-center items-center gap-2 transition-all duration-300 hover:text-rose-500'>
                   <span>Çıkış</span>
                   <span><IconGenerator name="fa-solid fa-right-from-bracket" /></span>

                </div>
            </div>

        </div>
    )
}

export default TopMenu