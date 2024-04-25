import React from 'react'
import CommentSectionTitle from './CommentSectionTitle'
import CommentHolderBody from './CommentHolderBody'
import CommentBody from './CommentBody'
import Comment from './Comment'

const WorkingSpaceCommentHolder = ({ comment }) => {
    return (
        <CommentHolderBody>
            <CommentSectionTitle />
             
                <Comment comment={comment} />
          
        </CommentHolderBody>
    )
}

export default WorkingSpaceCommentHolder