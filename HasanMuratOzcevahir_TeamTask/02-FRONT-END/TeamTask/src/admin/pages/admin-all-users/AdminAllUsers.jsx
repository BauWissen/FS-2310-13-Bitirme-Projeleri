import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { adminGetUserList } from './../../slices/adminGetUserListSlice'
import DataTable from 'react-data-table-component'
import { userDTC } from '../../../utilities/admin/userDTC'
import DataTableLoading from '../../../top-global-component/DataTableLoading'
import { setIsDeleted } from '../../slices/adminRemoveUserSlice'
import { setConfirmChanged } from '../../slices/adminToggleConfirmUserEmailSlice'
const AdminAllUsers = () => {


  const dispatch = useDispatch()
  const userList = useSelector(state => state.adminGetUserList)
  const isDeletedUser = useSelector(state => state.adminRemoveUser)
  const isConfirmChanged = useSelector(state => state.adminToggleUserEmailConfirm)
  console.log(isDeletedUser, " isdeleted")
  console.log(userList, "ulist")
  useEffect(() => {

    dispatch(adminGetUserList())

    if (isDeletedUser.isDeleted)
      dispatch(setIsDeleted()) // tricky, this is not the best way in every change request. will be fixed.
    if (isConfirmChanged.isChanged)
      dispatch(setConfirmChanged())


    console.log("çalıpıyor")
  }, [isDeletedUser.isDeleted, isConfirmChanged.isChanged])

  return (
    <div>
      {userList.isLoading && <DataTableLoading />}
      {userList.userList &&
        <DataTable
          onRowClicked={(row, event) => { alert(row.id) }}

          paginationPerPage={8}
          paginationRowsPerPageOptions={[8, 16, 32]}
          highlightOnHover
          striped
          title="KULLANICILAR"
          pagination

          columns={userDTC}
          data={userList.userList}
        />
      }
    </div>
  )
}

export default AdminAllUsers