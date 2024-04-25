import { NavLink, Outlet } from 'react-router-dom'
import AdminTopMenu from './sub-component/AdminTopMenu'
import { useSelector } from 'react-redux'
import TTLogo from './../../../css/logo/logoteta.png'
const AdminMain = () => {


  const user = useSelector((state) => state.currentUser.user)

  console.log(user, " user from adminmain page")

  return (

    <div className=' flex flex-col justify-center  text-white'>
      <div className='flex flex-col lg:flex-row lg:items-center bg-zinc-800 p-2 lg:p-10 gap-5'>
        <NavLink to='/admin' className='relative'>
          <img src={TTLogo} className='w-24 lg:w-60' alt="" />

          <div className='text-slate-300 font-extrabold absolute  w-full lg:right-0 lg:top-full flex '>
            <div className='flex  w-full justify-between'>
              <span>{user && user.user.firstName}</span>
              <span>admin</span>
            </div>

          </div>
        </NavLink>
        {/* <div className='flex'>
          <button id="dropdownDefaultButton" data-dropdown-toggle="dropdown" className="text-white p-5 bg-orange-500   " type="button">KULLANICI
          </button>
          <div id="dropdown" className="z-10 hidden mt-0 w-full bg-orange-400 ">
            <div className=" text-slate-800 font-semibold flex flex-col" aria-labelledby="dropdownDefaultButton">
              <span className=''>
                <NavLink to="/admin/allusers" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">MENU</NavLink>
              </span>
              <span className=''>
                <NavLink to="/admin/allusers" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">MENU</NavLink>
              </span>    <span className=''>
                <NavLink to="/admin/allusers" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">MENU</NavLink>
              </span>    <span className=''>
                <NavLink to="/admin/allusers" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">MENU</NavLink>
              </span>    <span className=''>
                <NavLink to="/admin/allusers" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">MENU</NavLink>
              </span>    <span className=''>
                <NavLink to="/admin/allusers" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">MENU</NavLink>
              </span>    <span className=''>
                <NavLink to="/admin/allusers" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">MENU</NavLink>
              </span>    <span className=''>
                <NavLink to="/admin/allusers" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">MENU</NavLink>
              </span>    <span className=''>
                <NavLink to="/admin/allusers" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">MENU</NavLink>
              </span>
            </div>
          </div>
        </div> */}
        <AdminTopMenu />
      </div>

      <div className='text-black lg:p-10 bg-zinc-300 rounded-md  my-4 lg:my-10 lg:mx-10 '>
        <div className='shadow-lg shadow-zinc-400 m-2'>
        <Outlet />
        </div>
     
      </div>
      <div className='text-slate-200 font-semibold p-10   bg-zinc-600 lg:mx-10'>
        kayıtlı kullanıcı vsvs
      </div>
      <div className='text-slate-200 font-semibold p-10   bg-zinc-800  mt-4 lg:mt-10'>
        FOOTER
      </div>

    </div>


  )

}

export default AdminMain