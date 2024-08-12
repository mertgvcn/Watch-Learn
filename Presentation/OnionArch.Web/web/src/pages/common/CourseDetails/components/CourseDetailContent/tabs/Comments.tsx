//models
import { CourseCommentDTO } from '../../../../../../models/DTOs/CourseCommentDTO'
//mui components
import { Box, Paper, Rating, Stack, Typography } from '@mui/material'
//icons
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

type CommentsType = {
    comments: CourseCommentDTO[]
}
const Comments = ({ comments }: CommentsType) => {

    return (
        <Stack direction="column" spacing={2}>

            {comments.map((comment, index) => (
                <Paper variant='outlined' key={index} sx={{
                    padding: "1rem",
                    boxSizing: "border-box"
                }}>

                    <Stack direction="row" spacing={1} sx={{ display: "flex", alignItems: "center" }}>
                        <AccountCircleIcon sx={{ fontSize: 40 }} />
                        <Stack direction="column">
                            <Typography variant='body1'>{comment.student.user.firstName} {comment.student.user.lastName}</Typography>
                            <Rating readOnly value={comment.rating} size='small' />
                        </Stack>
                    </Stack>

                    <Box sx={{
                        padding: "0.5rem 0.2rem",
                        boxSizing: "border-box"
                    }}>
                        <Typography>{comment.comment}</Typography>
                    </Box>
                </Paper>
            ))}

        </Stack>
    )
}

export default Comments