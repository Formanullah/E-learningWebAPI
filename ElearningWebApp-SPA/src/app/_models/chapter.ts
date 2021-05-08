import { Topic } from './topic';

export interface Chapter {
    id: number;
    name: string;
    subjectName: string;
    subjectForClassId: number;
    createdDate: Date;
    updateDate: Date;
    className: string;
    classId: number;
    topics?: Topic[];
}
