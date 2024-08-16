//model
import { CourseViewModel } from '../../../../../models/viewModels/CourseViewModel'
//mui components
import styled from '@emotion/styled'
import { Box } from '@mui/material'
//components
import Header from './components/Header';
import Teacher from './components/Teacher';

const HeaderBox = styled(Box)({
    display: "flex",
    flexDirection: "column",
    justifyContent: "space-between",
    maxWidth: "calc(100% - 400px)",
    height: "100%",
    padding: "2rem 0rem",
    boxSizing: "border-box"
})

type CourseDetailHeaderType = {
    title: string,
    shortDescription: string,
    teacherName: string
}

const CourseDetailHeader = ({ title, shortDescription, teacherName }: CourseDetailHeaderType) => {
    return (
        <HeaderBox>
            <Header
                title={title}
                shortDescription={shortDescription}
            />
            <Teacher
                teacherName={teacherName}
            />
        </HeaderBox>
    )
}

export default CourseDetailHeader