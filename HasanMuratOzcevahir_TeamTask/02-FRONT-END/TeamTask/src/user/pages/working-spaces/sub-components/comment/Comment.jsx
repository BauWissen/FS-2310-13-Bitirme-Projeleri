import React from 'react'
import CommentBody from './CommentBody'
import CommentUserInfo from './CommentUserInfo'
import CommentContent from './CommentContent'
const Comment = ({ comment }) => {
    return (
        comment.map(com =>
            <CommentBody key={com.id}>

                <CommentUserInfo name={com.fullName} date={com.createdDate} />

                <CommentContent content={com.comment} />



            </CommentBody>
        )
    )
}

export default Comment