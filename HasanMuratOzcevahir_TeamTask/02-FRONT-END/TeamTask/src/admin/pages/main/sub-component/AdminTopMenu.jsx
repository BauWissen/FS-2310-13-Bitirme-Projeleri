import React from 'react'
import { NavLink } from 'react-router-dom'
import AdminTopMenuItem from './AdminTopMenuItem'
import IconGenerator from '../../../../utilities/IconGenerator'
const AdminTopMenu = () => {
  return (
    <div className='flex flex-col lg:flex-row justify-between w-full lg:text-4xl gap-5 lg:gap-0'>
      <div className='flex flex-wrap lg:flex-row'>
        <AdminTopMenuItem link="/admin/allusers" title="Kullanıcılar" />
        <AdminTopMenuItem link="/admin/allworkingspaces" title="Çalışma Alanları" />
        <AdminTopMenuItem link="/admin/allusers" title="Kullanıcılar" />
  
      </div>
      <div className=' lg:text-3xl flex items-center justify-center  lg:gap-2 bg-sky-500 text-zinc-900 px-5 py-2 rounded-full'>
        <span>
          <IconGenerator name="fa-solid fa-angle-left" />
        </span>
        <NavLink to="/dashboard">Çalışma alanına geri dön</NavLink>
      </div>

    </div>
  )
}

export default AdminTopMenu