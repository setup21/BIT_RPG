using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
using UnityEngine.UI;

//수정 필요하다.
public class NetworkMgr : MonoBehaviour
{
    [SerializeField] private Text DBLogTxt;

    MySqlConnection sqlconn = null;
    //192.168.0.21
    private string sqlDBip      = "192.168.45.7";
    private string sqlDBname    = "bitrpg";
    private string sqlPortNum   = "3306";
    private string sqlDBid      = "root";
    private string sqlDBpw      = "12345";


    //192.168.45.7
    //bitrpg

    //"3.35.175.73";
    //"dancebike";
    //"root";
    //"vrcarver1234!";

    //"192.168.0.21";
    //"test";
    //"root";
    //"12345";

    private void Awake()
    {
        //DB정보 입력
        string sqlDatabase = "Server=" + sqlDBip + ";Port=" + sqlPortNum + ";Database=" + sqlDBname + ";UserId=" + sqlDBid + ";Password=" + sqlDBpw + "";
        //Debug.Log(sqlDatabase);
        sqlconn = new MySqlConnection(sqlDatabase);
    }
    private void sqlConnect()
    {
        //접속 확인하기
        try
        {            
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
                DBLogTxt.text = sqlconn.State.ToString();
                Debug.Log("SQL의 접속 상태 : " + sqlconn.State); //접속이 되면 OPEN이라고 나타남
            }                        
        }
        catch (System.Exception msg)
        {
            Debug.Log(msg); //기타다른오류가 나타나면 오류에 대한 내용이 나타남
        }
    }

    private void sqldisConnect()
    {
        if (sqlconn.State == ConnectionState.Open)
        {
            sqlconn.Close();
            DBLogTxt.text = sqlconn.State.ToString();
            Debug.Log("SQL의 접속 상태 : " + sqlconn.State); //접속이 끊기면 Close가 나타남 
        }        
        
    }

    public void sqlcmdall(string allcmd)
    {
        MySqlCommand dbcmd = new MySqlCommand(allcmd, sqlconn);
        dbcmd.ExecuteNonQuery();
    }

    public DataTable selsql(string sqlcmd)
    {
        DataTable dt = new DataTable();
        
        MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcmd, sqlconn);
        adapter.Fill(dt);

        Debug.Log(dt.Columns.Count);
        Debug.Log(dt.Rows.Count);
        string a = System.Convert.ToString(dt.Rows[0][0]);
        DBLogTxt.text = a;
        Debug.Log(a);

        return dt;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            sqlConnect();
        }
        if(Input.GetKey(KeyCode.C))
        {
            sqldisConnect();
        }
        if(Input.GetKey(KeyCode.V))
        {
            if(sqlconn.State == ConnectionState.Open)
            {
                selsql("use bitrpg; select Version from systeminfo");
                //try
                //{
                //    sqlcmdall("insert into systeminfo(version) values ('205');");
                //    Debug.Log("ADDED");
                //}
                //catch (System.Exception e)
                //{
                //    Debug.Log("중복");
                //}
                
            }
        }
    }
}
