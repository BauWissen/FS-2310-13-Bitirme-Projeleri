import React from 'react'
import { NavLink } from 'react-router-dom'

const AdminTopMenuItem = ({link,title}) => {
  return (
    <NavLink className="p-2 lg:p-4 transition-all duration-700 rounded-md hover:bg-orange-300 hover:text-zinc-900" to={link}>
      {title}
    </NavLink>
  )
}

export default AdminTopMenuItem