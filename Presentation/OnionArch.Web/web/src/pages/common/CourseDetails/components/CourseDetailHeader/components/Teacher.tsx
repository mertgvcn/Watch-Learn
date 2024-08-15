//mui components
import { Stack, Typography } from '@mui/material'
//icons
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

type TeacherType = {
    teacherName: string,
}

const Teacher = ({teacherName}: TeacherType) => {
    return (
        <Stack direction="row" spacing={0.5} sx={{ alignItems: "center" }}>
            <AccountCircleIcon sx={{ fontSize: 26 }} />
            <Typography variant='subtitle1'>{teacherName}</Typography>
        </Stack>
    )
}

export default Teacher