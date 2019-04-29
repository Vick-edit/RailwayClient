/*--------------------------Задание 1.1-------------------------------------*/
SELECT mainQ.*
FROM T mainQ
JOIN (
        SELECT outQ.ID, (SELECT COUNT (*) FROM T inQ WHERE inQ.Value > outQ.Value) as CountOfBigger
        FROM T outQ
     ) onMaxSubQ ON mainQ.ID = onMaxSubQ.ID
JOIN (
        SELECT outQ.ID, (SELECT COUNT (*) FROM T inQ WHERE inQ.Value < outQ.Value) as CountOfSmaller
        FROM T outQ
     ) onMinSubQ ON mainQ.ID = onMinSubQ.ID
WHERE onMaxSubQ.CountOfBigger = onMinSubQ.CountOfSmaller;

/*--------------------------Задание 1.2-------------------------------------*/
WITH TreeRecursive (ID, ParentID, Level, Path) as 
(
   SELECT mainRoot.ID, mainRoot.ParentID, 1 as Level, convert(varchar(max), mainRoot.ID) as Path
   FROM Tree mainRoot
   WHERE ParentID is null

   UNION ALL

   SELECT branch.ID, branch.ParentID, root.Level + 1 as Level, root.Path + '/' + convert(varchar(max), branch.ID) as Path
   FROM Tree branch 
   JOIN TreeRecursive root ON root.ID = branch.ParentID
)
SELECT *
FROM TreeRecursive
order by ID;