import { StudentDTO } from "./StudentDTO";

export interface CourseCommentDTO {
    id: number;
    comment: string;
    rating: number;
    student: StudentDTO
}