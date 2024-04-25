import React from 'react'
import { useSelector } from 'react-redux'

const WorkingSpaceDetail = () => {
  const user = useSelector((state) => state.currentUser.user)

  return (
    <div>{user.isAdmin && "yes adminsin workingspacedetailfortest"}</div>
  )
}

export default WorkingSpaceDetail